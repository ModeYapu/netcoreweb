using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace netCoreweb.Controllers
{
    /// <summary>
    /// 测试信息
    /// </summary>
    [Route("api/[controller]/[action]")]
    public class ValuesController : Controller
    {
        /// <summary>
        /// 获取所有信息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }
        /// <summary>
        /// 根据ID获取信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }
        /// <summary>
        /// POST了一个数据信息
        /// </summary>
        /// <param name="value"></param>
        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }
        /// <summary>
        /// 根据ID put 数据
        /// </summary>
        /// <param name="id"></param>
        /// <param name="value"></param>
        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }
        /// <summary>
        /// 根据ID删除数据
        /// </summary>
        /// <param name="id"></param>
        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
        /// <summary>
        /// 复杂数据操作
        /// </summary>
        /// <param name="id"></param>
        // DELETE api/values/5
        [HttpPost]
        public namevalue test(namevalue _info)
        {
            return _info;
        }
    }

    public class namevalue
    {
        /// <summary>
        /// name的信息
        /// </summary>
        public String name { get; set; }
        /// <summary>
        /// value的信息
        /// </summary>
        public String value { get; set; }
    }
}