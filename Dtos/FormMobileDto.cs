using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IRRIGA.Dtos
{
    public record FormMobileDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ICollection<FieldsetMobile> Fieldset { get; set; }
    }
	public record FieldsetMobile
	{
		public int Id { get; set; }
		public string Label { get; set; }
		public string [] DependOn { get; set; }
		public string Description { get; set; }
		public ICollection<Controls> Controls { get; set; }
	}

	public record Controls
	{
		public int Id { get; set; }
		public string Label { get; set; }
		public string DependOn { get; set; }
		public int VerifyOn { get; set; }
		public string Type { get; set; }
		public int LabelField { get; set; }
		public int FilterId { get; set; }
		public string FilterWithDropdown { get; set; }
		public string Placeholder { get; set; }
		public string Value { get; set; }
		public ICollection<Options> Options { get; set; }
		public Validators Validators { get; set; }
	}

	public record Options
	{
		public int Id { get; set; }
		public string Name { get; set; }
	}

	public record Validators
	{
		public bool Required { get; set; }
		public int Min { get; set; }
		public int Max { get; set; }
		public string ContentType { get; set; }

	}

	public record LocalData
    {
		public bool IsLocal { get; set; }
		public int LocalType { get; set; }
    }

	public record DependsOn
    {
		public int Id { get; set; }
		public int Value { get; set; }
    }
}

