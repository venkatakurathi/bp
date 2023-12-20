﻿using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.ApplicationInsights;
using Microsoft.ApplicationInsights.Extensibility;
using Microsoft.ApplicationInsights.DataContracts;
using System.Collections.Generic;

namespace BPCalculator
{
    // BP categories
    public enum BPCategory
    {
        [Display(Name = "Low Blood Pressure")] Low,
        [Display(Name = "Ideal Blood Pressure")] Ideal,
        [Display(Name = "Pre-High Blood Pressure")] PreHigh,
        [Display(Name = "High Blood Pressure")] High
    };

    public class BloodPressure
    {
        private const string InstrumentationKey = "Your-Instrumentation-Key";

        // Telemetry client
        private static TelemetryClient telemetryClient;

        // Initialize telemetry client
        static BloodPressure()
        {
            // Set up configuration
            TelemetryConfiguration configuration = TelemetryConfiguration.CreateDefault();
            configuration.ConnectionString = $"InstrumentationKey={InstrumentationKey}";

            // Initialize telemetry client
            telemetryClient = new TelemetryClient(configuration);
        }

        public const int SystolicMin = 70;
        public const int SystolicMax = 190;
        public const int DiastolicMin = 40;
        public const int DiastolicMax = 100;

        [Range(SystolicMin, SystolicMax, ErrorMessage = "Invalid Systolic Value")]
        public int Systolic { get; set; }                       // mmHG

        [Range(DiastolicMin, DiastolicMax, ErrorMessage = "Invalid Diastolic Value")]
        public int Diastolic { get; set; }                      // mmHG

        // calculate BP category
        public BPCategory Category
        {
            get
            {
                var category = CalculateCategory();

                // Log telemetry for blood pressure measurement
                LogTelemetry(category);

                return category;
            }
        }

        private BPCategory CalculateCategory()
        {
            if (Systolic < 90 && Diastolic < 60)
            {
                return BPCategory.Low;
            }
            else if ((Systolic >= 90 && Systolic <= 120) && (Diastolic >= 60 && Diastolic < 80))
            {
                return BPCategory.Ideal;
            }
            else if ((Systolic >= 120 && Systolic < 140) || (Diastolic >= 80 && Diastolic < 90))
            {
                return BPCategory.PreHigh;
            }
            else
            {
                return BPCategory.High;
            }
        }

        private void LogTelemetry(BPCategory category)
        {
            // Track a custom event for blood pressure measurement
            var eventProperties = new Dictionary<string, string>
            {
                { "Systolic", Systolic.ToString() },
                { "Diastolic", Diastolic.ToString() },
                { "Category", category.ToString() }
            };

            telemetryClient.TrackEvent("BloodPressureMeasurement", eventProperties);

            // Send telemetry to Azure
            telemetryClient.Flush();
        }
    }
}
