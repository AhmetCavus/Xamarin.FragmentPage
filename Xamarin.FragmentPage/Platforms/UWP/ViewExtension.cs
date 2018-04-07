using System;
using Xamarin.Forms;
using Xamarin.Forms.Platform.UWP;
using Windows.UI.Xaml;

namespace Cinary.Xamarin.Fragment.Platforms.UWP
{
    public static class ViewExtensions
    {
        private static readonly Type _platformType = Type.GetType("Xamarin.Forms.Platform.UWP", true);
        private static BindableProperty _rendererProperty;

        public static BindableProperty RendererProperty
        {
            get
            {
                //_rendererProperty = Platform.CreateRenderer()

                return _rendererProperty;
            }
        }

        public static IVisualElementRenderer GetRenderer(this VisualElement element)
        {
            return Platform.CreateRenderer(element);
        }

        public static FrameworkElement GetNativeView(this VisualElement element)
        {
            var renderer = Platform.CreateRenderer(element);
            var containerElement = renderer.ContainerElement;
            return containerElement;
        }

        public static void SetRenderer(this BindableObject bindableObject, IVisualElementRenderer renderer)
        {
            //			var value = bindableObject.GetValue (RendererProperty);
            bindableObject.SetValue(RendererProperty, renderer);
        }

        public static Point GetNativeScreenPosition(this VisualElement element)
        {
            var view = element.GetNativeView();
            var point = Point.Zero;
            if (view != null)
            {
                int[] location = new int[2];
                var p = view.TransformToVisual((UIElement)view.Parent).TransformPoint(new Windows.Foundation.Point(0.0, 0.0));
                point = new global::Xamarin.Forms.Point(location[0], location[1]);
            }
            return point;
        }

        /// <summary>
        /// Gets the or create renderer.
        /// </summary>
        /// <returns>The or create renderer.</returns>
        /// <param name="source">Source.</param>
        public static IVisualElementRenderer GetOrCreateRenderer(this VisualElement source)
        {
            var renderer = source.GetRenderer();
            if (renderer == null)
            {
                renderer = Platform.CreateRenderer(source);
                source.SetRenderer(renderer);
                renderer = source.GetRenderer();
            }
            return renderer;
        }
    }
}