using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RouteFinder.Graphs;

namespace RouteFinder.Controllers
{
    [ApiController] 
    [Route("[controller]")]
    public class RouteFinderController : ControllerBase
    {

        // Our North American Graph
        Graph NaGraph = new Graph();

        
        // Default when the url doesn't have an identifier
        [HttpGet]
        [Route("")]
        public ContentResult Default()
        {
            return Content("Enter a 3-letter Identifier at the end of the URL.");
        }

        // Endpoint for grabbing the 3-letter code in the url
        [HttpGet]
        [Route("{identifier}")]
        public IActionResult Get(string identifier)
        {
            // Create the NA graph and check if the identifier
            // exists as a vertex in the graph
            bool isFound = GraphHelper.CreateNAGraph(NaGraph, identifier);
            if (isFound == false)
            {
                return NotFound($"Not Found: {identifier}");
            }
            // Run BFS on the graph and get the goal vertex
            Vertex result = Algorithm.FindBFS(NaGraph);
            // check that the vertex was actually found 
            // in the search
            if (result == null)
            {
                return NotFound($"Not Found: {identifier}");
            }

            // Our path as a list from USA -> ... -> dest
            List<string> finalPath = GraphHelper.GetPath(result);

            // get a JSON object to send in the response
            string response = JsonConvert.SerializeObject(new
            {
                destination = identifier.ToUpper(),
                list = finalPath
            });
            return Ok(response);
        }
    }
}
