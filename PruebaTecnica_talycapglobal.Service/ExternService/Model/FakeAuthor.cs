using System;
using System.Collections.Generic;
using System.Text;

namespace PruebaTecnica_talycapglobal.Service.ExternService.Model
{
    /// <summary>
    /// class FakeAuthor
    /// </summary>
    public class FakeAuthor
    {
        /// <summary>
        /// Id de la tabla Author del servicio externo
        /// </summary>
        public int id { get; set; }
        /// <summary>
        /// idBook de la tabla Author del servicio externo
        /// </summary>
        public int idBook { get; set; }
        /// <summary>
        /// firstName de la tabla Author del servicio externo
        /// </summary>
        public string firstName { get; set; }
        /// <summary>
        /// lastName de la tabla Author del servicio externo
        /// </summary>
        public string lastName { get; set; }
    }
}
