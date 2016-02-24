// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Machinery_Abductor_Pad : Obj_Machinery_Abductor {

		public Base_Data teleport_target = null;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.anchored = 1;
			this.icon = "icons/obj/abductor.dmi";
			this.icon_state = "alien-pad-idle";
		}

		public Obj_Machinery_Abductor_Pad ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: pad.dm
		public void PadToLoc( Ent_Static place = null ) {
			Obj_Effect_TeleportAbductor F = null;
			EffectSystem_SparkSpread S = null;
			Mob_Living target = null;

			F = new Obj_Effect_TeleportAbductor( place );
			S = new EffectSystem_SparkSpread();
			S.set_up( 10, 0, place );
			S.start();
			Task13.Sleep( 80 );
			GlobalFuncs.qdel( F );
			Icon13.Flick( "alien-pad", this );

			foreach (dynamic _a in Lang13.Enumerate( this.loc, typeof(Mob_Living) )) {
				target = _a;
				
				target.forceMove( place );
				Task13.Schedule( 0, (Task13.Closure)(() => {
					GlobalFuncs.anim( target.loc, target, "icons/mob/mob.dmi", null, "uncloak", null, target.dir );
					return;
				}));
			}
			return;
		}

		// Function from file: pad.dm
		public void MobToLoc( Ent_Static place = null, dynamic target = null ) {
			Obj_Effect_TeleportAbductor F = null;
			EffectSystem_SparkSpread S = null;

			F = new Obj_Effect_TeleportAbductor( place );
			S = new EffectSystem_SparkSpread();
			S.set_up( 10, 0, place );
			S.start();
			Task13.Sleep( 80 );
			GlobalFuncs.qdel( F );
			Icon13.Flick( "alien-pad", this );
			((Ent_Dynamic)target).forceMove( place );
			GlobalFuncs.anim( target.loc, target, "icons/mob/mob.dmi", null, "uncloak", null, Convert.ToInt32( target.dir ) );
			return;
		}

		// Function from file: pad.dm
		public void Retrieve( dynamic target = null ) {
			Icon13.Flick( "alien-pad", this );
			Task13.Schedule( 0, (Task13.Closure)(() => {
				GlobalFuncs.anim( target.loc, target, "icons/mob/mob.dmi", null, "uncloak", null, Convert.ToInt32( target.dir ) );
				return;
			}));
			this.Warp( target );
			return;
		}

		// Function from file: pad.dm
		public void Send(  ) {
			Mob_Living target = null;

			
			if ( this.teleport_target == null ) {
				this.teleport_target = GlobalVars.teleportlocs[Rand13.PickFromTable( GlobalVars.teleportlocs )];
			}
			Icon13.Flick( "alien-pad", this );

			foreach (dynamic _a in Lang13.Enumerate( this.loc, typeof(Mob_Living) )) {
				target = _a;
				
				this.TeleportToArea( target, this.teleport_target );
				Task13.Schedule( 0, (Task13.Closure)(() => {
					GlobalFuncs.anim( target.loc, target, "icons/mob/mob.dmi", null, "uncloak", null, target.dir );
					return;
				}));
			}
			return;
		}

		// Function from file: pad.dm
		public void Warp( dynamic target = null ) {
			target.Move( this.loc );
			return;
		}

	}

}