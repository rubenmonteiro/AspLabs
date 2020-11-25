using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Diagnostics;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Threading;

namespace Microsoft.AspNetCore.Migration
{
    public static class DiagnosticDescriptors
    {
        internal const string ActionsShouldExplicitlySpecifyHttpMethodConstraintId = "MIG0001";

        internal static readonly DiagnosticDescriptor ActionsShouldExplicitlySpecifyHttpMethodConstraint = new DiagnosticDescriptor(
            ActionsShouldExplicitlySpecifyHttpMethodConstraintId,
            "Specify a HTTP Method attribute",
            "Controller actions should specify the HTTP method constraint.",
            "Usage",
            DiagnosticSeverity.Warning,
            isEnabledByDefault: true,
            description: "MVC does not infer the HTTP method based on a method name. HTTP method constraints should be explicitly specified.");

        internal const string ActionsRelyOnOverloadResolutionForRoutingId = "MIG0002";

        internal static readonly DiagnosticDescriptor ActionsRelyOnOverloadResolutionForRouting = new DiagnosticDescriptor(
            ActionsRelyOnOverloadResolutionForRoutingId,
            "Action relies on WebAPI overload resolution",
            "Controller actions should not use overload resolution for routing.",
            "Usage",
            DiagnosticSeverity.Warning,
            isEnabledByDefault: true,
            description: "WebAPI's action selection supports overload resolution (https://docs.microsoft.com/aspnet/web-api/overview/web-api-routing-and-actions/routing-and-action-selection#action-selection) that is not supported by ASP.NET Core. " +
            "Specify a distinct route for this action.");

        // Diagnostics to remove the shim.
        internal const string ControllersShouldUseApiControllerId = "MIG1000";

        internal static readonly DiagnosticDescriptor ControllersShouldUseApiController = new DiagnosticDescriptor(
            ControllersShouldUseApiControllerId,
            "Update controller base type.",
            "Controllers should derive from Microsoft.AspNetCore.Mvc.ControllerBase",
            "Usage",
            DiagnosticSeverity.Warning,
            isEnabledByDefault: true,
            description: "Update this controller to derive from an ASP.NET Core controller type.");
    }
}
