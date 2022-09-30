using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;
namespace AddressScrub.Models
{
    // Root myDeserializedClass = JsonSerializer.Deserialize<List<Root>>(myJsonResponse);
    public class Address
    {
        [JsonPropertyName("validate")]
        public bool? Validate { get; set; }

        [JsonPropertyName("blankIfInvalid")]
        public bool? BlankIfInvalid { get; set; }

        [JsonPropertyName("ncoa")]
        public bool? Ncoa { get; set; }

        [JsonPropertyName("line1")]
        public string? Line1 { get; set; } = "";

        [JsonPropertyName("line2")]
        public string? Line2 { get; set; } = "";

        [JsonPropertyName("city")]
        public string? City { get; set; } = "";

        [JsonPropertyName("state")]
        public string? State { get; set; }

        [JsonPropertyName("postalCode")]
        public string? PostalCode { get; set; }
    }

    public class Data
    {
        [JsonPropertyName("record")]
        public string Record { get; set; } = "";

        [JsonPropertyName("name")]
        public Name? Name { get; set; }

        [JsonPropertyName("dob")]
        public string? Dob { get; set; }

        [JsonPropertyName("ssn")]
        public string? Ssn { get; set; }

        [JsonPropertyName("address")]
        public Address? Address { get; set; }

        [JsonPropertyName("email")]
        public string? Email { get; set; }

        [JsonPropertyName("phone")]
        public string? Phone { get; set; }
    }

    public class Email
    {
        [JsonPropertyName("validate")]
        public bool? Validate { get; set; }

        [JsonPropertyName("blankIfInvalid")]
        public bool? BlankIfInvalid { get; set; }
    }

    public class Name
    {
        [JsonPropertyName("firstName")]
        public string? FirstName { get; set; }

        [JsonPropertyName("lastName")]
        public string? LastName { get; set; }
    }

    public class Options
    {
        [JsonPropertyName("removeDuplicates")]
        public bool RemoveDuplicates { get; set; }

        [JsonPropertyName("removeMinors")]
        public bool RemoveMinors { get; set; }

        [JsonPropertyName("removeSeniors")]
        public bool RemoveSeniors { get; set; }

        [JsonPropertyName("removeDeceased")]
        public bool? RemoveDeceased { get; set; }

        [JsonPropertyName("checkForInsurance")]
        public bool? CheckForInsurance { get; set; }

        [JsonPropertyName("skipTrace")]
        public bool? SkipTrace { get; set; }

        [JsonPropertyName("address")]
        public Address? Address { get; set; }

        [JsonPropertyName("email")]
        public Email? Email { get; set; }

        [JsonPropertyName("phone")]
        public Phone? Phone { get; set; }
    }

    public class Phone
    {
        [JsonPropertyName("validate")]
        public bool? Validate { get; set; }

        [JsonPropertyName("blankIfInvalid")]
        public bool? BlankIfInvalid { get; set; }
    }

    public class Root
    {
        [JsonPropertyName("id")]
        public string? Id { get; set; }

        [JsonPropertyName("title")]
        public string? Title { get; set; }

        [JsonPropertyName("options")]
        public Options? Options { get; set; }

        [JsonPropertyName("data")]
        public Array Data { get; set; }
    }
} 




