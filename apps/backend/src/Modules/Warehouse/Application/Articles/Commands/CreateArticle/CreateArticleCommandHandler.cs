using Application.Messaging.Commands;
using Shared.Results;
using Warehouse.Application.Suppliers;
using Warehouse.Domain.Articles;
using Warehouse.Domain.Suppliers;

namespace Warehouse.Application.Articles.Commands.CreateArticle
{
  public class CreateArticleCommandHandler : ICommandHandler<CreateArticleCommand>
  {
    private readonly ISupplierRepository _supplierRepository;
    private readonly ICreateArticleService _createArticleService;

    public CreateArticleCommandHandler(ICreateArticleService createArticleService, ISupplierRepository supplierRepository)
    {
      _createArticleService = createArticleService;
      _supplierRepository = supplierRepository;
    }

    public async Task<Result> Handle(CreateArticleCommand request, CancellationToken cancellationToken)
    {
      var supplier = await _supplierRepository.GetByIdAsync(request.Dto.SupplierId, cancellationToken);
      if (supplier is null)
      {
        return Result.Failure(new NotFoundError(nameof(Supplier)));
      }

      var result = await _createArticleService.ExecuteAsync(Article.Create(request.Dto, supplier), cancellationToken);

      return result;
    }
  }
}
