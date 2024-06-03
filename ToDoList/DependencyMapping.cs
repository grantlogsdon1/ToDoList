using Data.Repositories;
using Services;

namespace ToDoList
{
    public static class DependencyMapping
    {
        public static IServiceCollection MapDependencies(this IServiceCollection services)
        {
            // *** Map Repositories ***
            services.AddTransient<TodoListRepo>();

            // *** Map Services ***
            services.AddTransient<TodoListService>();

            // *** Map Shared Features ***

            return services;
        }
    }
}
