namespace ECommerce.WebUI.DTOs.Catalog.ProductDtos;

public record CreateProductDto(string Name,
                               string Description,
                               string ImageUrl,
                               decimal Price,
                               int Stock,
                               string CategoryName);
