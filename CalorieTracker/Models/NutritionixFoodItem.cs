using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

public class NutritionixFoodItem
{
    // [JsonProperty(PropertyName = "hit")]
    public int total_hits { get; set; }
    public float max_score { get; set; }
    public Hit[] hits { get; set; }
}

public class Hit
{
    
    public string _index { get; set; }
    public string _type { get; set; }
    public string _id { get; set; }
    public float _score { get; set; }
    public Fields fields { get; set; }
}

public class Fields
{
    public string item_id { get; set; }
    public string item_name { get; set; }
    public string brand_name { get; set; }
    public int nf_calories { get; set; }
    public int nf_serving_size_qty { get; set; }
    public string nf_serving_size_unit { get; set; }
}


//namespace CalorieTracker.Models
//{
//    public class NutritionixFoodItem
//    {

//    }
//}
