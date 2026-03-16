namespace ECommerce.WebUI.DTOs.Catalog.ProductDtos;

public record UpdateProductDto(string Id,
                               string Name,
                               string Description,
                               string ImageUrl,
                               decimal Price,
                               int Stock,
                               string CategoryName);
