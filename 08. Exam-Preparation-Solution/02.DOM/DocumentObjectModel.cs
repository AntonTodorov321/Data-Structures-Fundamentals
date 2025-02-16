namespace _02.DOM
{
    using System;
    using System.Text;
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
            this.ValidateElementExist(htmlElement);
            return htmlElement.AddAttribute(attrKey, attrValue);
        }

        public bool Contains(IHtmlElement htmlElement)
        {
            return this.FindElement(htmlElement) != null;
        }

        public IHtmlElement GetElementById(string idValue)
        {
            Queue<IHtmlElement> queue = new Queue<IHtmlElement>();
            queue.Enqueue(this.Root);

            while (queue.Count != 0)
            {
                IHtmlElement current = queue.Dequeue();

                if (current.HasId(idValue))
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

        public IHtmlElement GetElementByType(ElementType type)
        {
            Queue<IHtmlElement> queue = new Queue<IHtmlElement>();
            queue.Enqueue(this.Root);

            while (queue.Count != 0)
            {
                IHtmlElement element = queue.Dequeue();

                if (element.Type == type)
                {
                    return element;
                }

                foreach (var child in element.Children)
                {
                    queue.Enqueue(child);
                }
            }

            return null;
        }

        public List<IHtmlElement> GetElementsByType(ElementType type)
        {
            List<IHtmlElement> elements = new List<IHtmlElement>();
            this.GetByTypeDfs(type, this.Root, elements);

            return elements;
        }

        public void InsertFirst(IHtmlElement parent, IHtmlElement child)
        {
            this.ValidateElementExist(parent);
            parent.Children.Insert(0, child);
            child.Parent = parent;
        }

        public void InsertLast(IHtmlElement parent, IHtmlElement child)
        {
            this.ValidateElementExist(parent);
            parent.Children.Add(child);
            child.Parent = parent;
        }

        public void Remove(IHtmlElement htmlElement)
        {
            this.ValidateElementExist(htmlElement);

            htmlElement.Parent.Children.Remove(htmlElement);
            htmlElement.Parent = null;
            htmlElement.Children.Clear();
        }

        public void RemoveAll(ElementType elementType)
        {
            Queue<IHtmlElement> queue = new Queue<IHtmlElement>();
            queue.Enqueue(this.Root);

            while (queue.Count != 0)
            {
                IHtmlElement htmlElement = queue.Dequeue();

                if (htmlElement.Type == elementType)
                {
                    htmlElement.Parent.Children.Remove(htmlElement);
                    htmlElement.Parent = null;
                    htmlElement.Children.Clear();
                }

                foreach (var child in htmlElement.Children)
                {
                    queue.Enqueue(child);
                }
            }
        }

        public bool RemoveAttribute(string attrKey, IHtmlElement htmlElement)
        {
            this.ValidateElementExist(htmlElement);
            return htmlElement.RemoveAttribute(attrKey);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            this.DfsToString(this.Root, 0, sb);

            return sb.ToString();
        }

        private void DfsToString(IHtmlElement node, int indent, StringBuilder sb)
        {
            sb.Append(' ', indent)
                .AppendLine(node.Type.ToString());

            foreach (var child in node.Children)
            {
                this.DfsToString(child, indent + 2, sb);
            }
        }

        private void ValidateElementExist(IHtmlElement element)
        {
            if (!this.Contains(element))
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

        private void GetByTypeDfs(ElementType type, IHtmlElement node, List<IHtmlElement> elements)
        {
            foreach (var child in node.Children)
            {
                this.GetByTypeDfs(type, child, elements);
            }

            if (node.Type == type)
            {
                elements.Add(node);
            }
        }
    }
}
