using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class Instock : IProductStock
{
    private List<Product> products;

    public Instock()
    {
        this.products = new List<Product>();
    }

    public int Count => this.products.Count;

    public void Add(Product product)
    {
        if (!this.Contains(product))
        {
            this.products.Add(product);
        }
    }

    public void ChangeQuantity(string product, int quantity)
    {
        Product searchingProduct = this.FindByLabel(product);
        searchingProduct.Quantity = quantity;

        this.products.Remove(searchingProduct);
        this.products.Add(searchingProduct);
    }

    public bool Contains(Product product)
    {
        foreach (var currentProduct in this.products)
        {
            if (currentProduct.Label == product.Label)
            {
                return true;
            }
        }

        return false;
    }

    public Product Find(int index)
    {
        if (index < 0 || index >= this.products.Count)
        {
            throw new IndexOutOfRangeException();
        }

        return this.products[index];
    }

    public IEnumerable<Product> FindAllByPrice(double price)
    {
        List<Product> searchingProducts = new List<Product>();

        foreach (var product in this.products)
        {
            if (product.Price == price)
            {
                searchingProducts.Add(product);
            }
        }

        return searchingProducts;
    }

    public IEnumerable<Product> FindAllByQuantity(int quantity)
    {
        List<Product> searchingProducts = new List<Product>();

        foreach (var product in this.products)
        {
            if (product.Quantity == quantity)
            {
                searchingProducts.Add(product);
            }
        }

        return searchingProducts;
    }

    public IEnumerable<Product> FindAllInRange(double lo, double hi)
    {
        List<Product> searchingProducts = new List<Product>();

        foreach (var product in this.products)
        {
            if (product.Price > lo && product.Price <= hi)
            {
                searchingProducts.Add(product);
            }
        }

        return searchingProducts.OrderByDescending(products => products.Price);
    }

    public Product FindByLabel(string label)
    {
        foreach (var product in this.products)
        {
            if (product.Label == label)
            {
                return product;
            }
        }

        throw new ArgumentException();
    }

    public IEnumerable<Product> FindFirstByAlphabeticalOrder(int count)
    {
        if (count > this.products.Count)
        {
            throw new ArgumentException();
        }

        return this.products.OrderBy(product => product.Label).Take(count);
    }

    public IEnumerable<Product> FindFirstMostExpensiveProducts(int count)
    {
        if (count > this.products.Count)
        {
            throw new ArgumentException();
        }

        return this.products.OrderByDescending(product => product.Price).Take(count);
    }

    public IEnumerator<Product> GetEnumerator()
    {
        foreach (var product in this.products)
        {
            yield return product;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }
}
