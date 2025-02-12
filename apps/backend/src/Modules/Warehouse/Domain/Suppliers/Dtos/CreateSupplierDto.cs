using Domain.Primitives.Interfaces;
using Shared.Results.Response;
using System.ComponentModel.DataAnnotations;

namespace Warehouse.Domain.Suppliers.Dtos
{
  public class CreateSupplierDto : IDto
  {
    [Required]
    [TranslationKey("COLUMN_NAME_SBN_ID")]
    [Sortable]
    public required int SbnId { get; set; }

    [Required]
    [TranslationKey("COLUMN_NAME_NAME")]
    [Sortable(false)]
    public required string Name { get; set; }

    [TranslationKey("COLUMN_NAME_IS_ACTIVE")]
    [Sortable]
    public bool IsActive { get; set; }
  }
}
