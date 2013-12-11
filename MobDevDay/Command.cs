//
// Command.cs
//
// Author:
//       Stephane Delcroix <stephane@mi8.be>
//
// Copyright (c) 2013 mobile inception
//
using System;
using System.Windows.Input;

namespace MobDevDay
{
	public sealed class Command<T>
		: Command
	{
		public Command (Action<T> execute)
			: base (o => execute((T)o))
		{
			if (execute == null)
				throw new ArgumentNullException ("execute");
		}

		public Command (Action<T> execute, Func<T, bool> canExecute)
			: base (o => execute((T)o), o => canExecute ((T)o))
		{
			if (execute == null)
				throw new ArgumentNullException ("execute");
			if (canExecute == null)
				throw new ArgumentNullException ("canExecute");
		}
	}

	public class Command
		: ICommand
	{
		public event EventHandler CanExecuteChanged;

		public Command (Action<object> execute)
		{
			if (execute == null)
				throw new ArgumentNullException ("execute");

			this.execute = execute;
		}

		public Command (Action execute)
			: this (o => execute())
		{
			if (execute == null)
				throw new ArgumentNullException ("execute");
		}

		public Command (Action<object> execute, Func<object, bool> canExecute)
			: this (execute)
		{
			if (canExecute == null)
				throw new ArgumentNullException ("canExecute");

			this.canExecute = canExecute;
		}

		public Command (Action execute, Func<bool> canExecute)
			: this (o => execute(), o => canExecute())
		{
			if (execute == null)
				throw new ArgumentNullException ("execute");
			if (canExecute == null)
				throw new ArgumentNullException ("canExecute");
		}

		public void Execute (object parameter)
		{
			this.execute (parameter);
		}

		public bool CanExecute (object parameter)
		{
			if (this.canExecute != null)
				return this.canExecute (parameter);

			return true;
		}

		public void ChangeCanExecute()
		{
			var changed = CanExecuteChanged;
			if (changed != null)
				changed (this, EventArgs.Empty);
		}

		private readonly Func<object, bool> canExecute;
		private readonly Action<object> execute;
	}
}