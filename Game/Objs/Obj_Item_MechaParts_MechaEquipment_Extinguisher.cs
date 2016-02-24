// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_MechaParts_MechaEquipment_Extinguisher : Obj_Item_MechaParts_MechaEquipment {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.equip_cooldown = 5;
			this.range = 3;
			this.icon_state = "mecha_exting";
		}

		// Function from file: work_tools.dm
		public Obj_Item_MechaParts_MechaEquipment_Extinguisher ( dynamic loc = null ) : base( (object)(loc) ) {
			this.create_reagents( 1000 );
			this.reagents.add_reagent( "water", 1000 );
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			return;
		}

		// Function from file: work_tools.dm
		public override bool can_attach( Obj_Mecha M = null ) {
			
			if ( base.can_attach( M ) ) {
				
				if ( M is Obj_Mecha_Working ) {
					return true;
				}
			}
			return false;
		}

		// Function from file: work_tools.dm
		public override void on_reagent_change(  ) {
			return;
		}

		// Function from file: work_tools.dm
		public override string get_equip_info(  ) {
			return "" + base.get_equip_info() + " [" + this.reagents.total_volume + "]";
		}

		// Function from file: work_tools.dm
		[VerbInfo( name: "action" )]
		[VerbArg( 1, InputType.Mob | InputType.Obj | InputType.Tile | InputType.Zone )]
		public override bool f_action( dynamic target = null ) {
			dynamic WT = null;
			int direction = 0;
			dynamic T = null;
			Tile T1 = null;
			Tile T2 = null;
			ByTable the_targets = null;
			int? a = null;
			dynamic W = null;
			dynamic my_target = null;
			Reagents R = null;
			int? b = null;
			dynamic W_turf = null;
			Ent_Static atm = null;

			
			if ( !this.action_checks( target ) || Map13.GetDistance( this.chassis, target ) > 3 ) {
				return false;
			}

			if ( target is Obj_Structure_ReagentDispensers_Watertank && Map13.GetDistance( this.chassis, target ) <= 1 ) {
				WT = target;
				((Reagents)WT.reagents).trans_to( this, 1000 );
				this.occupant_message( "<span class='notice'>Extinguisher refilled.</span>" );
				GlobalFuncs.playsound( this.chassis, "sound/effects/refill.ogg", 50, 1, -6 );
			} else {
				
				if ( ( this.reagents.total_volume ??0) > 0 ) {
					GlobalFuncs.playsound( this.chassis, "sound/effects/extinguish.ogg", 75, 1, -3 );
					direction = Map13.GetDistance( this.chassis, target );
					T = GlobalFuncs.get_turf( target );
					T1 = Map13.GetStep( T, Num13.Rotate( direction, 90 ) );
					T2 = Map13.GetStep( T, Num13.Rotate( direction, -90 ) );
					the_targets = new ByTable(new object [] { T, T1, T2 });
					Task13.Schedule( 0, (Task13.Closure)(() => {
						a = null;
						a = 0;

						while (( a ??0) < 5) {
							W = GlobalFuncs.PoolOrNew( typeof(Obj_Effect_ParticleEffect_Water), GlobalFuncs.get_turf( this.chassis ) );

							if ( !Lang13.Bool( W ) ) {
								return;
							}
							my_target = Rand13.PickFromTable( the_targets );
							R = new Reagents( 5 );
							W.reagents = R;
							R.my_atom = W;
							this.reagents.trans_to( W, 1 );
							b = null;
							b = 0;

							while (( b ??0) < 4) {
								
								if ( !Lang13.Bool( W ) ) {
									return;
								}
								Map13.StepTowardsSimple( W, my_target );

								if ( !Lang13.Bool( W ) ) {
									return;
								}
								W_turf = GlobalFuncs.get_turf( W );
								((Reagents)W.reagents).reaction( W_turf );

								foreach (dynamic _a in Lang13.Enumerate( W_turf, typeof(Ent_Static) )) {
									atm = _a;
									
									((Reagents)W.reagents).reaction( atm );
								}

								if ( W.loc == my_target ) {
									break;
								}
								Task13.Sleep( 2 );
								b++;
							}
							a++;
						}
						return;
					}));
				}
				return true;
			}
			return false;
		}

	}

}