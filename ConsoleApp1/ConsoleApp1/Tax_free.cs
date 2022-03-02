using System.ComponentModel;

namespace ConsoleApp1;

public enum Country
{
    Italy,
    France,
    Germany
}

public class TaxFree
{
    private int id;
    private string companyName;
    private int vatRate;
    private DateTime dateOfPurcase;
    private string vatCode;
    private Country country;
    private DateTime dateOfTaxRegistration;

    public TaxFree InputData()
    {
        foreach (PropertyDescriptor prop in TypeDescriptor.GetProperties(this))
        {
            if (prop.Name != "id")
            {
                Console.Write($"{prop.Name}: ");
                prop.SetValue(this, Convert.ChangeType(Console.ReadLine(), prop.PropertyType));
            }
            this.Id = Guid.NewGuid().ToString();
        }

        return this;
    }
    public string Id { get; set; }
    
    public string Company
    {
        get => companyName; 
        set => companyName = Validation.setComapnyName(value); 
    }
        
    public int VatRate
    {
        get => vatRate; 
        set => vatRate = Validation.setVatRate(value); 
    }
        
    public DateTime DateOfPurchase
    {
        get => dateOfPurcase;
        set => dateOfPurcase = Validation.setDateOfPurchase(value); 
    }
        
    public string VatCode
    {
        get => vatCode;
        set => vatCode = Validation.setVatCode(value);
    }
       
    public Country Country
    {
        get => country;
        set => country = Validation.setCountry(value);
    }
        
    public DateTime DateOfTaxRegistration
    {
        get => dateOfTaxRegistration;
        set => dateOfTaxRegistration = Validation.setDataOfRefistrationTax(value, dateOfPurcase);
    }

    public override string ToString() {
        string res = "";
        foreach (PropertyDescriptor prop in TypeDescriptor.GetProperties(this)) 
            res += ($"{prop.Name}: {prop.GetValue(this)}\n");
        return res.Substring(0, res.Length-1);
    }

}