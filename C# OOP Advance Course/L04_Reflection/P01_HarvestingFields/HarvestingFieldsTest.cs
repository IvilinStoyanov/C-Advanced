namespace P01_HarvestingFields
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    public class HarvestingFieldsTest
    {
        public static object IEnumurable { get; private set; }

        public static void Main()
        {
            // Getting all fields 
            var allFields = Type.GetType("P01_HarvestingFields.HarvestingFields")
                            .GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);

            string command;
            while ((command = Console.ReadLine()) != "HARVEST")
            {
                IEnumerable<FieldInfo> fieldsToPrint = null;
                switch (command)
                {
                    case "public":
                        fieldsToPrint = allFields.Where(f => f.IsPublic);
                        break;
                    case "private":
                        fieldsToPrint = allFields.Where(f => f.IsPrivate);
                        break;
                    case "protected":
                        fieldsToPrint = allFields.Where(f => f.IsFamily);
                        break;
                    case "all":
                        fieldsToPrint = allFields;
                        break;
                    default:
                        throw new ArgumentException($"{command.GetType().Name} is not valid command");
                }

                foreach (var field in fieldsToPrint)
                {
                    Print(field);
                }
            }
        }

        private static void Print(FieldInfo field)
        {
            var fieldAttributes = field.Attributes.ToString().ToLower();

            if(fieldAttributes == "family")
            {
                fieldAttributes = "protected";
            }

            var fieldInfo = $"{fieldAttributes} {field.FieldType.Name} {field.Name}";
            Console.WriteLine(fieldInfo);
        }
    }
}
