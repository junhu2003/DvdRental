using DvdRental.Library.Handlers;

namespace DvdRental.Library.Models
{
    public class DvdRentalContext
    {
        public DateTime DateAccept { get; set; }
        public DvdRentalInputs? Inputs { get; set; }
        public DvdRentalOutputs? Outputs { get; set; }
        public List<HandlerType> HandlersExecuted { get; set; } = new List<HandlerType>();

        public DvdRentalContext()
        { 
            Outputs = new DvdRentalOutputs();
        }

        public Actor? Actor { get; set; }

        public Customer? Customer { get; set; } 
        public List<Customer>? Customers { get; set; }
        
    }
}
