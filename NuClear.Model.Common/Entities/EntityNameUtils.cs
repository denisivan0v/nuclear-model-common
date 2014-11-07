using System.Text;

namespace NuClear.Model.Common.Entities
{
    public static partial class EntityNameUtils
    {
       
        public static string EntitiesToString(this IEntityName[] entityNames)
        {
            if (entityNames == null || entityNames.Length == 0)
            {
                return "Entities list is empty";
            }

            var sb = new StringBuilder();
            sb.Append(entityNames[0].ToString());
            for (int i = 1; i < entityNames.Length; i++)
            {
                sb.Append(";")
                  .Append(entityNames[i].ToString());
            }

            return sb.ToString();
        }
    }
}
