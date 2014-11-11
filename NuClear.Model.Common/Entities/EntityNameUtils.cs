using System.Text;

namespace NuClear.Model.Common.Entities
{
    public static partial class EntityNameUtils
    {
       
        public static string EntitiesToString(this EntityType[] entityTypes)
        {
            if (entityTypes == null || entityTypes.Length == 0)
            {
                return "Entities list is empty";
            }

            var sb = new StringBuilder();
            sb.Append(entityTypes[0].ToString());
            for (int i = 1; i < entityTypes.Length; i++)
            {
                sb.Append(";")
                  .Append(entityTypes[i].ToString());
            }

            return sb.ToString();
        }
    }
}
