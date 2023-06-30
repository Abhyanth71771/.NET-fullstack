using System.ComponentModel.DataAnnotations.Schema;

namespace EFCoreRelatedEntities
{
public class Brand
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int BrandId { get; set; }
        public string BrandName { get; set; }
        public virtual ICollection<Models> Models { get; set; }


    }

public class Models
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ModelId { get; set; }
        public string ModelName { get; set; }
    }
}