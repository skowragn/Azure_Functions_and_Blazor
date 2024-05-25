using CarsManager.Domain.Entities;
using CarsManager.Application.Interfaces;
using CarsManager.Orleans.Infrastructure.Persistence.DbContext;

namespace CarsManager.Infrastructure.Persistence.Repositories;

public class CarsBookedItemRepository(AppDbContext context) : Repository<CarsBookedItem>(context), ICarsBookedItemRepository
{
}