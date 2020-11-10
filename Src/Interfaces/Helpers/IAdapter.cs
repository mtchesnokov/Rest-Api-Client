using System.Threading.Tasks;

namespace Tch.RestClient.Interfaces.Helpers
{
   internal interface IAdapterSync<TSource, TDestination>
   {
      TDestination AdaptSync(TSource source);
   }

   internal interface IAdapterAsync<TSource, TDestination>
   {
      Task<TDestination> AdaptAsync(TSource source);
   }
}