using System.Reflection;

namespace Core.Args
{
    public abstract class AArgs
    {
        const BindingFlags flags =
            BindingFlags.Public |
            BindingFlags.Instance |
            BindingFlags.Static;

        private string toString = null;

        public virtual string GetArgs ()
        {
            PropertyInfo[] properties = GetType().GetProperties(flags);
            string[] propertyInfos = new string[properties.Length];

            for (int i = 0; i < properties.Length; ++i)
            {
                if (properties[i].PropertyType.IsSubclassOf(typeof(AArgs)))
                {
                    propertyInfos[i] = string.Format("{0}({1})", properties[i].Name, ((AArgs)properties[i].GetValue(this)).GetArgs());
                }
                else
                {
                    propertyInfos[i] = string.Format("{0}={1}", properties[i].Name, properties[i].GetValue(this));
                }
            }
            return string.Join(", ", propertyInfos).ToLower();
        }

        public override string ToString ()
        {
            if (toString is null)
            {
                toString = GetArgs();
            }
            return toString;
        }
    }
}
