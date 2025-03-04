using System.Collections.Generic;
using System.Globalization;
using Xunit.Internal;

namespace Xunit.v3;

/// <summary>
/// This message is sent when code (1st or 3rd party) wants to alert the user to a situation that may require
/// diagnostic investigation. This is typically not displayed unless the user has explicitly asked for diagnostic
/// messages to be displayed (see <see href="https://xunit.net/docs/configuration-files#diagnosticMessages"/> on
/// how to enable display of diagnostic messages).
/// </summary>
public class _DiagnosticMessage : _MessageSinkMessage
{
	string? message;

	/// <summary>
	/// Gets or sets the diagnostic message.
	/// </summary>
	public string Message
	{
		get => this.ValidateNullablePropertyValue(message, nameof(Message));
		set => message = Guard.ArgumentNotNull(value, nameof(Message));
	}

	/// <inheritdoc/>
	public override string ToString() =>
		string.Format(CultureInfo.CurrentCulture, "{0} message={1}", GetType().Name, message.Quoted());

	/// <inheritdoc/>
	protected override void ValidateObjectState(HashSet<string> invalidProperties)
	{
		base.ValidateObjectState(invalidProperties);

		ValidateNullableProperty(message, nameof(Message), invalidProperties);
	}
}
