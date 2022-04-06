using System.ComponentModel;
using System.Reflection;

namespace ConsoleApp1;

using System.Text.Json;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

public class Collection
{
    private List<TaxFree> listCompanies;

    public Collection()
    {
        listCompanies = new List<TaxFree>();
    }

    public Collection(List<TaxFree> listCompanies)
    {
        this.listCompanies = listCompanies;
    }

    public void addElement(TaxFree company)
    {
        listCompanies.Add(company);
    }

    public void sortField(String fieldName)
    {
        List<TaxFree> sortedList = new List<TaxFree>();
        try
        {
            sortedList = listCompanies.OrderBy(e => e.GetType().GetProperty(fieldName).GetValue(e, null)).ToList();
        }
        catch (Exception)
        {
            throw new ArgumentException("Wrong Field name!");
        }
    }


    public List<TaxFree> search(String searchParam)
    {
        bool SearchPredicater(TaxFree elem)
        {
            foreach (PropertyDescriptor prop in TypeDescriptor.GetProperties(elem)) 
                if (prop.GetValue(elem).ToString().Contains(searchParam)) return true;
            return false;
        }
        var filtered = Validation.searchValidation(listCompanies.FindAll(SearchPredicater));
        return filtered;
    }

    public static T ParseEnum<T>(string value)
    {
        return (T) Enum.Parse(typeof(T), value, true);
    }
    
    public Collection ReadJsonFile(string fileName)
    {
        using (StreamReader r = new StreamReader(fileName))
        {
            string json = r.ReadToEnd();
            var dictionarys = JsonConvert.DeserializeObject<List<Dictionary<string, string>>>(json);
            foreach (var child in dictionarys)
            {
                try
                {
                    TaxFree p = JsonConvert.DeserializeObject<TaxFree>(JsonConvert.SerializeObject( child ));
                    if (string.IsNullOrEmpty(p.Id)) p.Id = Guid.NewGuid().ToString();
                    this.addElement(p);
                }
                catch (Exception e) { Console.WriteLine($"->{e.InnerException.Message}"); }
            }
        }
        return this;
    }
        
    public void WriteJsonFile(string fileName)
    {
        string json = JsonConvert.SerializeObject(this.listCompanies.ToArray());
        System.IO.File.WriteAllText(fileName, json);
    }

    public void DeleteById(string id)
    {
        var n = listCompanies.Find(x => x.Id == id);
        if (n != null) listCompanies.Remove(n);
    }

    public void Edit(string id, string atter, string value)
    {
        var findedById = listCompanies.Find(x => x.Id == id);
        if (findedById != null)
        {
            if (value == null)
            {
                Console.WriteLine("wrong atrr");
            }
            else
            {
                PropertyInfo propertyInfo = findedById.GetType().GetProperty(atter);
                propertyInfo.SetValue(findedById, Convert.ChangeType(value, propertyInfo.PropertyType), null);
            }
        }
    }

    public override string ToString()
    {
        string res = "";
        foreach (TaxFree element in listCompanies)
            res += element.ToString() + "\n\n";
        return "\n" + res.Substring(0, res.Length - 3);
    }
}