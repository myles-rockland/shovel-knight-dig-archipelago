using System.IO;
using System.Reflection;
using UnityEngine;

namespace ShovelKnightDigAPClient.Utils
{
    public static class BundleLoader
    {

        public static AssetBundle LoadEmbeddedBundle(string resourceName)
        {
            var assembly = Assembly.GetExecutingAssembly();

            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            {
                if (stream == null)
                {
                    Debug.LogError($"Resource not found: {resourceName}");
                    return null;
                }

                byte[] buffer = new byte[stream.Length];
                stream.Read(buffer, 0, buffer.Length);

                return AssetBundle.LoadFromMemory(buffer);
            }
        }
    }
}