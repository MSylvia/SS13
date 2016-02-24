// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Effect_ProcHolder_Spell_Targeted_AreaTeleport : Obj_Effect_ProcHolder_Spell_Targeted {

		public bool randomise_selection = false;
		public bool invocation_area = true;
		public string sound1 = "sound/weapons/ZapBang.ogg";
		public string sound2 = "sound/weapons/ZapBang.ogg";

		protected override void __FieldInit() {
			base.__FieldInit();

			this.nonabstract_req = true;
		}

		public Obj_Effect_ProcHolder_Spell_Targeted_AreaTeleport ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: area_teleport.dm
		[VerbInfo( name: "invocation" )]
		[VerbArg( 1, InputType.Zone )]
		[VerbArg( 2, InputType.Mob )]
		public override void f_invocation( dynamic chosenarea = null, dynamic user = null ) {
			user = user ?? Task13.User;

			
			if ( !this.invocation_area || !Lang13.Bool( chosenarea ) ) {
				base.f_invocation( (object)(chosenarea), (object)(user) );
			} else {
				
				switch ((string)( this.invocation_type )) {
					case "shout":
						((Ent_Dynamic)user).say( "" + this.invocation + " " + String13.ToUpper( chosenarea.name ) );

						if ( user.gender == GlobalVars.MALE ) {
							GlobalFuncs.playsound( user.loc, Rand13.Pick(new object [] { "sound/misc/null.ogg", "sound/misc/null.ogg" }), 100, 1 );
						} else {
							GlobalFuncs.playsound( user.loc, Rand13.Pick(new object [] { "sound/misc/null.ogg", "sound/misc/null.ogg" }), 100, 1 );
						}
						break;
					case "whisper":
						user.__CallVerb("Whisper", "" + this.invocation + " " + String13.ToUpper( chosenarea.name ) );
						break;
				}
			}
			return;
		}

		// Function from file: area_teleport.dm
		public override bool cast( dynamic targets = null, dynamic thearea = null, dynamic user = null ) {
			user = user ?? Task13.User;

			Mob_Living target = null;
			ByTable L = null;
			dynamic T = null;
			bool clear = false;
			Obj O = null;
			ByTable tempL = null;
			dynamic attempt = null;
			bool success = false;

			GlobalFuncs.playsound( GlobalFuncs.get_turf( user ), this.sound1, 50, 1 );

			foreach (dynamic _c in Lang13.Enumerate( targets, typeof(Mob_Living) )) {
				target = _c;
				
				L = new ByTable();

				foreach (dynamic _b in Lang13.Enumerate( GlobalFuncs.get_area_turfs( thearea.type ) )) {
					T = _b;
					

					if ( !T.density ) {
						clear = true;

						foreach (dynamic _a in Lang13.Enumerate( T, typeof(Obj) )) {
							O = _a;
							

							if ( O.density ) {
								clear = false;
								break;
							}
						}

						if ( clear ) {
							L.Add( T );
						}
					}
				}

				if ( !( L.len != 0 ) ) {
					Task13.User.WriteMsg( "The spell matrix was unable to locate a suitable teleport destination for an unknown reason. Sorry." );
					return false;
				}

				if ( target != null && target.buckled != null ) {
					target.buckled.unbuckle_mob();
				}
				tempL = L;
				attempt = null;
				success = false;

				while (tempL.len != 0) {
					attempt = Rand13.PickFromTable( tempL );
					target.Move( attempt );

					if ( GlobalFuncs.get_turf( target ) == attempt ) {
						success = true;
						break;
					} else {
						tempL.Remove( attempt );
					}
				}

				if ( !success ) {
					target.loc = Rand13.PickFromTable( L );
					GlobalFuncs.playsound( GlobalFuncs.get_turf( user ), this.sound2, 50, 1 );
				}
			}
			return false;
		}

		// Function from file: area_teleport.dm
		public override dynamic before_cast( dynamic targets = null ) {
			dynamic A = null;
			dynamic thearea = null;

			A = null;

			if ( !this.randomise_selection ) {
				A = Interface13.Input( "Area to teleport to", "Teleport", A, null, GlobalVars.teleportlocs, InputType.Any );
			} else {
				A = Rand13.PickFromTable( GlobalVars.teleportlocs );
			}
			thearea = GlobalVars.teleportlocs[A];
			return thearea;
		}

		// Function from file: area_teleport.dm
		public override void perform( dynamic targets = null, bool? recharge = null, dynamic user = null ) {
			recharge = recharge ?? true;
			user = user ?? Task13.User;

			Mob thearea = null;

			thearea = this.before_cast( targets );

			if ( !( thearea != null ) || !this.cast_check( true ) ) {
				this.revert_cast();
				return;
			}
			this.f_invocation( thearea, user );
			Task13.Schedule( 0, (Task13.Closure)(() => {
				
				if ( this.charge_type == "recharge" && recharge == true ) {
					this.start_recharge();
				}
				return;
			}));
			this.cast( targets, thearea, user );
			this.after_cast( targets );
			return;
		}

	}

}