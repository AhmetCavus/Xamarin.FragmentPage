using System;

namespace Plugin.Xamarin.FragmentPage
{
    /// <summary>
    /// Cross Xamarin.FragmentPage
    /// </summary>
    public static class CrossXamarin.FragmentPage
    {
        static Lazy<IXamarin.FragmentPage> implementation = new Lazy<IXamarin.FragmentPage>(() => CreateXamarin.FragmentPage(), System.Threading.LazyThreadSafetyMode.PublicationOnly);

        /// <summary>
        /// Gets if the plugin is supported on the current platform.
        /// </summary>
        public static bool IsSupported => implementation.Value == null ? false : true;

        /// <summary>
        /// Current plugin implementation to use
        /// </summary>
        public static IXamarin.FragmentPage Current
        {
            get
            {
                IXamarin.FragmentPage ret = implementation.Value;
                if (ret == null)
                {
                    throw NotImplementedInReferenceAssembly();
                }
                return ret;
            }
        }

        static IXamarin.FragmentPage CreateXamarin.FragmentPage()
        {
#if NETSTANDARD1_0 || NETSTANDARD2_0
            return null;
#else
#pragma warning disable IDE0022 // Use expression body for methods
            return new Xamarin.FragmentPageImplementation();
#pragma warning restore IDE0022 // Use expression body for methods
#endif
        }

        internal static Exception NotImplementedInReferenceAssembly() =>
            new NotImplementedException("This functionality is not implemented in the portable version of this assembly.  You should reference the NuGet package from your main application project in order to reference the platform-specific implementation.");

    }
}
