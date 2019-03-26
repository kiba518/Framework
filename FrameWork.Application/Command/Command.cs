using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrameWork.Application.Utilities;

namespace FrameWork.Application.Command
{
    [Serializable]
    public class Command : ICommand
    {
        #region Ctor
        /// <summary>
        /// Initializes a new instance of the <c>Command</c> class.
        /// </summary>
        public Command()
        {
        }
        /// <summary>
        /// Initializes a new instance of the <c>Command</c> class.
        /// </summary>
        /// <param name="id">The identifier which identifies a single command instance.</param>
        public Command(Guid id)
        {
            this.ID = id;
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Returns the hash code for current command object.
        /// </summary>
        /// <returns>The calculated hash code for the current command object.</returns>
        public override int GetHashCode()
        {
            return Utility.GetHashCode(this.ID.GetHashCode());
        }
        /// <summary>
        /// Returns a <see cref="System.Boolean"/> value indicating whether this instance is equal to a specified
        /// object.
        /// </summary>
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            Command cmd = obj as Command;
            if ((object)cmd == null)
                return false;
            return this.Equals((ICommand)cmd);
        }
        #endregion

        #region IEntity Members
        /// <summary>
        /// Gets or sets the identifier of the command instance.
        /// </summary>
        public virtual Guid ID
        {
            get;
            set;
        }

        #endregion

        #region IEquatable<IEntity> Members
        /// <summary>
        /// Returns a <see cref="System.Boolean"/> value indicating whether this instance is equal to a specified
        /// object.
        /// </summary>
        public virtual bool Equals(ICommand other)
        {
            if (object.ReferenceEquals(this, other))
                return true;
            if ((object)other == null)
                return false;
            if (!(other is Command))
                return false;
            Command otherCommand = other as Command;
            return this.ID.Equals(otherCommand.ID);
        }

        #endregion

    }
}
