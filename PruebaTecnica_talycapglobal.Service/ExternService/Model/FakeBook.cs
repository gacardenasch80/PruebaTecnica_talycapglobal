using System;
using System.Collections.Generic;
using System.Text;

namespace PruebaTecnica_talycapglobal.Service.ExternService.Model
{
    /// <summary>
    /// class FakeBook
    /// </summary>
    public class FakeBook
    {
        /// <summary>
        /// Id de la tabla Book del servicio externo
        /// </summary>
        public int id { get; set; }
        /// <summary>
        /// Id de la tabla Book del servicio externo
        /// </summary>
        public string title { get; set; }
        /// <summary>
        /// description de la tabla Book del servicio externo
        /// </summary>
        public string description { get; set; }
        /// <summary>
        /// pageCount de la tabla Book del servicio externo
        /// </summary>
        public int pageCount { get; set; }
        /// <summary>
        /// excerpt de la tabla Book del servicio externo
        /// </summary>
        public string excerpt { get; set; }
        /// <summary>
        /// publishDate de la tabla Book del servicio externo
        /// </summary>
        public DateTime publishDate { get; set; }
    }
}
