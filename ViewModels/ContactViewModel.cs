using ModernWMC.Models.Concrete;

namespace ModernWMC.ViewModels
{
    public class ContactViewModel
    {
        public List<Phone> Phones { get; set; }
        public List<Email> Emails { get; set; }
        public List<Address> Addresses { get; set; }
        public List<Map> Maps { get; set; }
    }
}
