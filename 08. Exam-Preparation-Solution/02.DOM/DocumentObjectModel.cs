namespace _02.DOM
{
    using System;
    using System.Collections.Generic;

    using _02.DOM.Interfaces;
    using _02.DOM.Models;

    public class DocumentObjectModel : IDocument
    {
        public DocumentObjectModel(IHtmlElement root)
        {
            this.Root = root;
        }

        public DocumentObjectModel()
        {
            this.Root =
                    new HtmlElement(ElementType.Document,
                      new HtmlElement(ElementType.Html,
                         new HtmlElement(ElementType.Head),
                         new HtmlElement(ElementType.Body)));
        }

        public IHtmlElement Root { get; private set; }

        public bool AddAttribute(string attrKey, string attrValue, IHtmlElement htmlElement)
        {
            throw new NotImplementedException();
        }

        public bool Contains(IHtmlElement htmlElement)
        {
            return this.FindElement(htmlElement) != null;
        }

        public IHtmlElement GetElementById(string idValue)
        {
            throw new NotImplementedException();
        }

        public IHtmlElement GetElementByType(ElementType type)
        {
            throw new NotImplementedException();
        }

        public List<IHtmlElement> GetElementsByType(ElementType type)
        {
            throw new NotImplementedException();
        }

        public void InsertFirst(IHtmlElement parent, IHtmlElement child)
        {
            this.ElementExist(parent);
            parent.Children.Insert(0, child);
            child.Parent = parent;
        }

        public void InsertLast(IHtmlElement parent, IHtmlElement child)
        {
            this.ElementExist(parent);
            parent.Children.Add(child);
            child.Parent = parent;
        }

        public void Remove(IHtmlElement htmlElement)
        {
            throw new NotImplementedException();
        }

        public void RemoveAll(ElementType elementType)
        {
            throw new NotImplementedException();
        }

        public bool RemoveAttribute(string attrKey, IHtmlElement htmlElement)
        {
            throw new NotImplementedException();
        }

        private void ElementExist(IHtmlElement parent)
        {
            IHtmlElement element = this.FindElement(parent);

            if (element == null)
            {
                throw new InvalidOperationException();
            }
        }

        private IHtmlElement FindElement(IHtmlElement element)
        {
            Queue<IHtmlElement> queue = new Queue<IHtmlElement>();
            queue.Enqueue(this.Root);

            while (queue.Count > 0)
            {
                IHtmlElement current = queue.Dequeue();

                if (current == element)
                {
                    return current;
                }

                foreach (var child in current.Children)
                {
                    queue.Enqueue(child);
                }
            }

            return null;
        }
    }
}
