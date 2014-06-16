using System;
namespace libplatform {

	
	[System.Serializable]
	public class UnsupportedPlatformException : PlatformException
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="T:UnsupportedPlatformException"/> class
		/// </summary>
		public UnsupportedPlatformException ()
		{
		}
		
		/// <summary>
		/// Initializes a new instance of the <see cref="T:UnsupportedPlatformException"/> class
		/// </summary>
		/// <param name="message">A <see cref="T:System.String"/> that describes the exception. </param>
		public UnsupportedPlatformException (string message) : base (message)
		{
		}
		
		/// <summary>
		/// Initializes a new instance of the <see cref="T:UnsupportedPlatformException"/> class
		/// </summary>
		/// <param name="message">A <see cref="T:System.String"/> that describes the exception. </param>
		/// <param name="inner">The exception that is the cause of the current exception. </param>
		public UnsupportedPlatformException (string message, Exception inner) : base (message, inner)
		{
		}
		
		/// <summary>
		/// Initializes a new instance of the <see cref="T:UnsupportedPlatformException"/> class
		/// </summary>
		/// <param name="context">The contextual information about the source or destination.</param>
		/// <param name="info">The object that holds the serialized object data.</param>
		protected UnsupportedPlatformException (System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : base (info, context)
		{
		}
	}

	[System.Serializable]
	public class PlatformException : Exception
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="T:PlatformException"/> class
		/// </summary>
		public PlatformException ()
		{
		}
		
		/// <summary>
		/// Initializes a new instance of the <see cref="T:PlatformException"/> class
		/// </summary>
		/// <param name="message">A <see cref="T:System.String"/> that describes the exception. </param>
		public PlatformException (string message) : base (message)
		{
		}
		
		/// <summary>
		/// Initializes a new instance of the <see cref="T:PlatformException"/> class
		/// </summary>
		/// <param name="message">A <see cref="T:System.String"/> that describes the exception. </param>
		/// <param name="inner">The exception that is the cause of the current exception. </param>
		public PlatformException (string message, Exception inner) : base (message, inner)
		{
		}
		
		/// <summary>
		/// Initializes a new instance of the <see cref="T:PlatformException"/> class
		/// </summary>
		/// <param name="context">The contextual information about the source or destination.</param>
		/// <param name="info">The object that holds the serialized object data.</param>
		protected PlatformException (System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : base (info, context)
		{
		}
	}
}
