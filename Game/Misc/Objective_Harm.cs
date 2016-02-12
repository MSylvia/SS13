// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Objective_Harm : Objective {

		public bool already_completed = false;

		public Objective_Harm ( string text = null ) : base( text ) {
			
		}

		// Function from file: objective.dm
		public override dynamic check_completion(  ) {
			Mob_Living H = null;
			Organ_External E = null;
			Organ_External_Head head = null;

			
			if ( this.blocked ) {
				return 0;
			}

			if ( this.already_completed ) {
				return 1;
			}

			if ( Lang13.Bool( this.target ) && Lang13.Bool( this.target.current ) && this.target.current is Mob_Living_Carbon_Human ) {
				
				if ( Convert.ToInt32( this.target.current.stat ) == 2 ) {
					return 0;
				}
				H = this.target.current;

				foreach (dynamic _a in Lang13.Enumerate( ((dynamic)H).organs, typeof(Organ_External) )) {
					E = _a;
					

					if ( ( E.status & 32 ) != 0 ) {
						this.already_completed = true;
						return 1;
					}

					if ( ( E.status & 64 ) != 0 && !E.amputated ) {
						this.already_completed = true;
						return 1;
					}
				}
				head = ((Mob_Living_Carbon_Human)H).get_organ( "head" );

				if ( head.disfigured ) {
					return 1;
				}
			}
			return 0;
		}

		// Function from file: objective.dm
		public override dynamic find_target_by_role( dynamic role = null, bool? role_type = null ) {
			role_type = role_type ?? false;

			base.find_target_by_role( (object)(role), role_type );

			if ( Lang13.Bool( this.target ) && Lang13.Bool( this.target.current ) ) {
				this.explanation_text = "Make an example of " + this.target.current.real_name + ", the " + ( !( role_type == true ) ? this.target.assigned_role : this.target.special_role ) + ". Break one of their bones, detach one of their limbs or disfigure their face. Make sure they're alive when you do it.";
			} else {
				this.explanation_text = "Free Objective";
			}
			return this.target;
		}

		// Function from file: objective.dm
		public override dynamic find_target(  ) {
			base.find_target();

			if ( Lang13.Bool( this.target ) && Lang13.Bool( this.target.current ) ) {
				this.explanation_text = "Make an example of " + this.target.current.real_name + ", the " + this.target.assigned_role + ". Break one of their bones, detach one of their limbs or disfigure their face. Make sure they're alive when you do it.";
			} else {
				this.explanation_text = "Free Objective";
			}
			return this.target;
		}

	}

}