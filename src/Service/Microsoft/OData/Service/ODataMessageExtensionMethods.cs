//   OData .NET Libraries
//   Copyright (c) Microsoft Corporation
//   All rights reserved. 

//   Licensed under the Apache License, Version 2.0 (the ""License""); you may not use this file except in compliance with the License. You may obtain a copy of the License at http://www.apache.org/licenses/LICENSE-2.0 

//   THIS CODE IS PROVIDED ON AN  *AS IS* BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING WITHOUT LIMITATION ANY IMPLIED WARRANTIES OR CONDITIONS OF TITLE, FITNESS FOR A PARTICULAR PURPOSE, MERCHANTABLITY OR NON-INFRINGEMENT. 

//   See the Apache Version 2.0 License for specific language governing permissions and limitations under the License.

namespace Microsoft.OData.Service
{
    using System.Diagnostics;
    using System.IO;
    using Microsoft.OData.Core;

    /// <summary>
    /// Extension methods classes in WCF Data Services Server.
    /// </summary>
    internal static class ODataMessageExtensionMethods
    {
        /// <summary>
        /// Set the response stream. 
        /// </summary>
        /// <param name ="message">The message that we are setting the stream for.</param>
        /// <param name="stream">Stream to which the response needs to be written.</param>
        internal static void SetStream(this IODataResponseMessage message, Stream stream)
        {
            AstoriaResponseMessage astoriaResponseMessage = message as AstoriaResponseMessage;
            ODataBatchOperationResponseMessage batchResponseMessage = message as ODataBatchOperationResponseMessage;

            if (astoriaResponseMessage != null)
            {
                Debug.Assert(stream != null, "When we call SetStream on a non-batch response message, the stream shouldn't be null.");
                astoriaResponseMessage.SetStream(stream);
            }
            else if (batchResponseMessage != null)
            {
                Debug.Assert(stream == null, "When we call SetStream, if we are in a batch operation, then the stream should be null.");
            }
            else
            {
                Debug.Fail("SetStream called on an unknown message type.");
            }
        }

        /// <summary>
        /// Gets the Request-If-Match header from the request.
        /// </summary>
        /// <param name="message">Message to get header from.</param>
        /// <returns>Value of the request if match header.</returns>
        internal static string GetRequestIfMatchHeader(this IODataRequestMessage message)
        {
            return message.GetHeader(XmlConstants.HttpRequestIfMatch);
        }
        
        /// <summary>
        /// Gets the Request-If-None-Match header from the request.
        /// </summary>
        /// <param name="message">Message to get header from.</param>
        /// <returns>Value of the request if none match header.</returns>
        internal static string GetRequestIfNoneMatchHeader(this IODataRequestMessage message)
        {
            return message.GetHeader(XmlConstants.HttpRequestIfNoneMatch);
        }

        /// <summary>
        /// Gets the Request Accept Charset header from the request.
        /// </summary>
        /// <param name="message">Message to get header from.</param>
        /// <returns>Value of the Request Accept Charset header.</returns>
        internal static string GetRequestAcceptCharsetHeader(this IODataRequestMessage message)
        {
            return message.GetHeader(XmlConstants.HttpRequestAcceptCharset);
        }
    }
}
