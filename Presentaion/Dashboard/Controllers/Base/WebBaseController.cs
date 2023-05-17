namespace TemplateFwExample.Dashboard.Controllers
{
    public partial class WebBaseController<C> : OperatinResultController where C : WebBaseController<C>
    {
        private ILogger<C> _logger;

        protected ILogger<C> Logger => _logger ??= HttpContext.RequestServices.GetService<ILogger<C>>();

        public WebBaseController() : base()
        {
        }

        #region  GetActionName
        public string GetActionName()
        {
            var routeDateValues = this.RouteData.Values;
            if (routeDateValues.ContainsKey("action"))
            {
                return (string)routeDateValues["action"];
            }

            return string.Empty;
        }
        #endregion

        #region  GetControllerName
        public string GetControllerName()
        {
            var routeDateValues = RouteData.Values;
            if (routeDateValues.ContainsKey("controller"))
            {
                return (string)routeDateValues["controller"];
            }

            return string.Empty;
        }
        #endregion


        

    }
}

