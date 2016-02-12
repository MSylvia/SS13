// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Machinery_Gibber_Autogibber : Obj_Machinery_Gibber {

		public ByTable allowedTypes = new ByTable(new object [] { typeof(Mob_Living_Carbon_Human), typeof(Mob_Living_Carbon_Alien), typeof(Mob_Living_Carbon_Monkey), typeof(Mob_Living_SimpleAnimal_Corgi) });
		public Ent_Static input_plate = null;

		// Function from file: gibber.dm
		public Obj_Machinery_Gibber_Autogibber ( dynamic loc = null ) : base( (object)(loc) ) {
			dynamic i = null;
			dynamic input_obj = null;

			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			Task13.Schedule( 5, (Task13.Closure)(() => {
				
				foreach (dynamic _a in Lang13.Enumerate( GlobalVars.cardinal )) {
					i = _a;
					
					input_obj = Lang13.FindIn( typeof(Obj_Machinery_Mineral_Input), Map13.GetStep( this.loc, Convert.ToInt32( i ) ) );

					if ( Lang13.Bool( input_obj ) ) {
						
						if ( input_obj.loc is Tile ) {
							this.input_plate = input_obj.loc;
							GlobalFuncs.qdel( input_obj );
							break;
						}
					}
				}

				if ( !( this.input_plate != null ) ) {
					GlobalVars.diary.WriteMsg( "a " + this + " didn't find an input plate." );
					return;
				}
				return;
			}));
			return;
		}

		// Function from file: gibber.dm
		public override dynamic process(  ) {
			ByTable affecting = null;
			Ent_Dynamic A = null;
			Ent_Dynamic M = null;
			dynamic t = null;

			
			if ( !( this.input_plate != null ) ) {
				return null;
			}

			if ( ( this.stat & 3 ) != 0 ) {
				return null;
			}
			this.f_use_power( 100 );
			affecting = this.input_plate.contents;
			Task13.Schedule( 1, (Task13.Closure)(() => {
				
				foreach (dynamic _b in Lang13.Enumerate( affecting, typeof(Ent_Dynamic) )) {
					A = _b;
					

					if ( A is Mob ) {
						M = A;

						if ( M.loc == this.input_plate ) {
							
							foreach (dynamic _a in Lang13.Enumerate( this.allowedTypes )) {
								t = _a;
								

								if ( Lang13.Bool( t.IsInstanceOfType( M ) ) ) {
									M.loc = this;
									this.startautogibbing( M );
									break;
								}
							}
						}
					}
				}
				return;
			}));
			return null;
		}

	}

}