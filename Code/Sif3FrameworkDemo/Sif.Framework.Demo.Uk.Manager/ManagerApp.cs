﻿/*
 * Crown Copyright © Department for Education (UK) 2016
 * 
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 * 
 *     http://www.apache.org/licenses/LICENSE-2.0
 * 
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

using log4net;
using Sif.Framework.Consumers;
using Sif.Framework.Model.Infrastructure;
using Sif.Framework.Model.Responses;
using Sif.Framework.Utils;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace Sif.Framework.Demo.Uk.Consumer
{

    class ManagerApp
    {
        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        
        void RunPayloadConsumer()
        {
            FunctionalServiceConsumer consumer = new FunctionalServiceConsumer();
            try
            {
                consumer.Register();
                if (log.IsInfoEnabled) log.Info("Registered the Consumer.");

                // Create a new payload job.
                if (log.IsInfoEnabled) log.Info("*** Listing jobs.");
                List<Job> jobs = consumer.Query("Payload");
                foreach(Job job in jobs)
                {
                    if (log.IsInfoEnabled) log.Info("Can access " + job.Name + " job (" + job.Id + ").");
                }

                // Admin interface, e.g.
                // /services/{job name(s)}/admin/owns/{job id} returns owner id
            }
            catch (Exception e)
            {
                log.Fatal(e.StackTrace);
                throw new Exception(this.GetType().FullName, e);
            }
            finally
            {
                consumer.Unregister();
                if (log.IsInfoEnabled) log.Info("Unregistered the Consumer.");
            }
        }

        static void Main(string[] args)
        {
            ManagerApp app = new ManagerApp();
            try
            {
                app.RunPayloadConsumer();
            }
            catch (Exception e)
            {
                if (log.IsErrorEnabled) log.Error("Error running the SIF3 demo.\n" + ExceptionUtils.InferErrorResponseMessage(e), e);
            }

            Console.WriteLine("Press any key to continue ...");
            Console.ReadKey();
        }

    }

}
