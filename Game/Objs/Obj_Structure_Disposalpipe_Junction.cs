// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Structure_Disposalpipe_Junction : Obj_Structure_Disposalpipe {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.icon_state = "pipe-j1";
		}

		// Function from file: disposal-structures.dm
		public Obj_Structure_Disposalpipe_Junction ( dynamic loc = null, Game_Data make_from = null ) : base( (object)(loc), make_from ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;

			dynamic _a = ((dynamic)this.stored).ptype; // Was a switch-case, sorry for the mess.
			if ( _a==2 ) {
				this.dpdir = this.dir | Num13.Rotate( this.dir, -90 ) | Num13.Rotate( this.dir, 180 );
			} else if ( _a==3 ) {
				this.dpdir = this.dir | Num13.Rotate( this.dir, 90 ) | Num13.Rotate( this.dir, 180 );
			} else if ( _a==4 ) {
				this.dpdir = this.dir | Num13.Rotate( this.dir, 90 ) | Num13.Rotate( this.dir, -90 );
			}
			this.update();
			return;
		}

		// Function from file: disposal-structures.dm
		public override double? nextdir( int fromdir = 0, double? sortTag = null ) {
			int flipdir = 0;
			double? mask = null;
			double? setbit = null;

			flipdir = Num13.Rotate( fromdir, 180 );

			if ( flipdir != this.dir ) {
				return this.dir;
			} else {
				mask = base.nextdir( fromdir, sortTag );
				setbit = 0;

				if ( ( ((int)( mask ??0 )) & 1 ) != 0 ) {
					setbit = GlobalVars.NORTH;
				} else if ( ( ((int)( mask ??0 )) & 2 ) != 0 ) {
					setbit = GlobalVars.SOUTH;
				} else if ( ( ((int)( mask ??0 )) & 4 ) != 0 ) {
					setbit = GlobalVars.EAST;
				} else {
					setbit = GlobalVars.WEST;
				}

				if ( Rand13.PercentChance( 50 ) ) {
					return setbit;
				} else {
					return ((int)( mask ??0 )) & ~((int)( setbit ??0 ));
				}
			}
			return null;
		}

	}

}