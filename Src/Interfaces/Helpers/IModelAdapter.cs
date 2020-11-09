namespace Tch.HttpClient.Interfaces.Helpers
{
   internal interface IModelAdapter<TModel>
   {
      string ToJsonText(TModel source);
   }
}