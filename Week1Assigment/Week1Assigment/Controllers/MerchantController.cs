using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace Week1Assigment.Controller;

public class Merchant
{
    [Key]
    public int Id { get; set; }
    [Required]
    [StringLength(maximumLength: 50, MinimumLength = 10 , ErrorMessage = "Name must be between 10 and 50 characters.")]
    public string Name { get; set; }
    [Required]
    [StringLength(maximumLength: 10, MinimumLength = 5 , ErrorMessage = "Addres must be between 5 and 10 characters.")]
    public string Address { get; set; }
    [Required]
    [EmailAddress (ErrorMessage = "Please provide a valid email address.")]
    public string Email { get; set; }
    [Required]
    [Phone (ErrorMessage = "Please provide a valid phone number.")]
    public string Phone { get; set; }
    [Required]
    public DateTime OpenDate { get; set; }
}

[Route("api/[controller]")]
[ApiController]
public class MerchantInformationController : ControllerBase
{
    private static List<Merchant> merchants = new List<Merchant>
    {
        new Merchant
        {
            Id = 1,
            Name = "Migros Market",
            Address = "Silivri/Istanbul",
            Email = "migros@gmail.com",
            Phone = "2126507088",
            OpenDate = new DateTime(2018, 9, 20)
        },
        new Merchant
        {
            Id = 2,
            Name = "Bim Market",
            Address = "Zeytinburnu/Istanbul",
            Email = "bim@gmail.com",
            Phone = "2126504081",
            OpenDate = new DateTime(1990, 9, 21)
        },
        new Merchant
        {
            Id = 3,
            Name = "Dilara Market",
            Address = "Corlu/Tekirdag",
            Email = "dilaramarkt@gmail.com",
            Phone = "2123506088",
            OpenDate = new DateTime(1998, 12, 24)
        }
    };
    
    //Get all merchants
    [HttpGet("GetAll")]
    public IActionResult GetAll()
    {
        return Ok(merchants);
    }
    
    //Get merchant by id
    [HttpGet("GetbyId/{id}")]
    public IActionResult Get([FromRoute] int id)
    {
        if (!merchants.Any(x => x.Id == id))
        {
            return NotFound("No merchant found with given Id");
        } 
        return Ok(merchants.FirstOrDefault(x => x.Id == id));
    }
    
    //Create merchant
    [HttpPost("Post")]
    public IActionResult Post([FromBody] Merchant newMerchant)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        Merchant merchant = merchants.FirstOrDefault(x => x.Id == newMerchant.Id);
        
        if (merchant != null)
        {
            return BadRequest("Merchant already exists");
        }
        newMerchant.Id = merchants.Count > 0 ? merchants.Max(x => x.Id) + 1 : 1;
        merchants.Add(newMerchant);
        return Ok(newMerchant);
        
    }
    
    //Update Merchant
    [HttpPut("{id}")]
    public IActionResult Put([FromRoute] int id , [FromBody] Merchant updatedMerchant)
    {
        if (!merchants.Any(x => x.Id == id))
        {
            return NotFound("No merchant found with given Id");
        } 
        
        Merchant merchant = merchants.FirstOrDefault(x => x.Id == id);
        merchant.Name = updatedMerchant.Name;
        merchant.Address = updatedMerchant.Address;
        merchant.Email = updatedMerchant.Email;
        merchant.Phone = updatedMerchant.Phone;
        merchant.OpenDate = updatedMerchant.OpenDate;
        
        return Ok(merchant);
        
    }
    
    //Delete Merchant
    [HttpDelete("{id}")]
    public IActionResult Delete([FromRoute] int id)
    {
        Merchant merchant = merchants.FirstOrDefault(x => x.Id == id);

        if (merchant == null)
        { 
            return NotFound("No merchant found with given Id");
        }
        merchants.Remove(merchant);
        return Ok();
        
    } 

}