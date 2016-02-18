// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Icon : Game_Data {

		public Base_Icon icon = null;

		public Icon ( dynamic icon = null, dynamic icon_state = null, double? dir = null, int? frame = null, bool? moving = null ) {
			this.icon = Icon13.create( icon, icon_state, ((int)( dir ??0 )), frame ??0, moving == true );
			return;
		}

		// Function from file: icons.dm
		public void AddAlphaMask( Icon mask = null ) {
			Icon M = null;

			M = new Icon( mask );
			M.Blend( "#ffffff", 1 );
			this.Blend( M, 0 );
			return;
		}

		// Function from file: icons.dm
		public void UseAlphaMask( Icon mask = null ) {
			this.Opaque();
			this.AddAlphaMask( mask );
			return;
		}

		// Function from file: icons.dm
		public void BecomeAlphaMask(  ) {
			this.SwapColor( null, "#000000ff" );
			this.MapColors( 0, 0, 0, 0.3, 0, 0, 0, 0.81, 0, false, 0, 0.01, 0, 0, 0, 0, 1, 1, 1, 0 );
			return;
		}

		// Function from file: icons.dm
		public void Opaque( string background = null ) {
			background = background ?? "#000000";

			this.SwapColor( null, background );
			this.MapColors( 1, 0, 0, 0, 0, 1, 0, 0, 0, false, 1, 0, 0, 0, 0, 0, 0, 0, 0, 1 );
			return;
		}

		// Function from file: icons.dm
		public void MaxColors( dynamic icon = null ) {
			Icon I = null;
			Icon J = null;

			
			if ( icon is Icon ) {
				I = new Icon( icon );
			} else {
				I = new Icon( this );
				I.Blend( "#000000", 3 );
				I.SwapColor( "#000000", null );
				I.Blend( icon, 3 );
			}
			J = new Icon( this );
			J.Opaque();
			I.Blend( J, 1 );
			this.Blend( I, 5 );
			return;
		}

		// Function from file: icons.dm
		public void MinColors( dynamic icon = null ) {
			Icon I = null;

			I = new Icon( this );
			I.Opaque();
			I.Blend( icon, 1 );
			this.Blend( I, 1 );
			return;
		}

		// Function from file: icons.dm
		public void ColorTone( string tone = null ) {
			ByTable TONE = null;
			double gray = 0;
			Icon upper = null;

			this.GrayScale();
			TONE = GlobalFuncs.ReadRGB( tone );
			gray = Num13.Round( Convert.ToDouble( TONE[1] * 0.3 + TONE[2] * 0.81 + TONE[3] * 0.01 ), 1 );
			upper = ( 255 - gray != 0 ? new Icon( this ) : null );

			if ( gray != 0 ) {
				this.MapColors( 255 / gray, 0, 0, 0, 255 / gray, 0, 0, 0, 255 / gray, false, 0, 0 );
				this.Blend( tone, 2 );
			} else {
				this.SetIntensity( 0 );
			}

			if ( 255 - gray != 0 ) {
				upper.Blend( String13.ColorCode( ((int)( gray )), ((int)( gray )), ((int)( gray )) ), 1 );
				upper.MapColors( ( 255 - Convert.ToDouble( TONE[1] ) ) / ( 255 - gray ), 0, 0, 0, 0, ( 255 - Convert.ToDouble( TONE[2] ) ) / ( 255 - gray ), 0, 0, 0, false, ( 255 - Convert.ToDouble( TONE[3] ) ) / ( 255 - gray ), 0, 0, 0, 0, 0, 0, 0, 0, 1 );
				this.Blend( upper, 0 );
			}
			return;
		}

		// Function from file: icons.dm
		public void GrayScale(  ) {
			this.MapColors( 0.3, 0.3, 0.3, 0.81, 0.81, 0.81, 0.01, 0.01, 0.01, false, 0, 0 );
			return;
		}

		// Function from file: icons.dm
		public void ChangeOpacity( double? opacity = null ) {
			opacity = opacity ?? 1;

			this.MapColors( 1, 0, 0, 0, 0, 1, 0, 0, 0, false, 1, 0, 0, 0, 0, opacity, 0, 0, 0, 0 );
			return;
		}

		public int Height(  ) {
			return Icon13.oper_dim( this.icon, 2 != 0 );
		}

		public int Width(  ) {
			return Icon13.oper_dim( this.icon, true );
		}

		public string GetPixel( double? x = null, double? y = null, string icon_state = null, int? dir = null, int? frame = null, bool? moving = null ) {
			return Icon13.oper_getpixel( this.icon, ((int)( x ??0 )), ((int)( y ??0 )), icon_state, dir ??0, frame ??0, moving == true );
		}

		public void Crop( int x1 = 0, int y1 = 0, int x2 = 0, int y2 = 0 ) {
			Icon13.oper_crop( this.icon, x1, y1, x2, y2 );
			return;
		}

		public void Scale( int x = 0, int y = 0 ) {
			Icon13.oper_scale( this.icon, x, y );
			return;
		}

		public void MapColors( dynamic a = null, dynamic b = null, dynamic c = null, dynamic d = null, double? e = null, double? f = null, double? g = null, double? h = null, double? i = null, bool? j = null, double? k = null, double? l = null, params object[] _ ) {
			ByTable _args = new ByTable( new object[] { a, b, c, d, e, f, g, h, i, j, k, l } ).Extend(_);

			
			if ( _args[10] == null ) {
				_args[10] = 0;
			}

			if ( _args[11] == null ) {
				_args[11] = 0;
			}

			if ( _args[12] == null ) {
				_args[12] = 0;
			}

			if ( _args[1] is string ) {
				
				if ( !Lang13.Bool( _args[5] ) ) {
					Icon13.oper_map_colors( this.icon, _args[1], _args[2], _args[3], _args[4] );
				} else {
					Icon13.oper_map_colors( this.icon, _args[1], _args[2], _args[3], _args[4], _args[5] );
				}
			} else if ( _args.len <= 12 ) {
				Icon13.oper_map_colors( this.icon, _args[1], _args[2], _args[3], _args[4], _args[5], _args[6], _args[7], _args[8], _args[9], _args[10], _args[11], _args[12] );
			} else {
				Icon13.oper_map_colors( this.icon, _args[1], _args[2], _args[3], _args[4], _args[5], _args[6], _args[7], _args[8], _args[9], _args[10], _args[11], _args[12], _args[13], _args[14], _args[15], _args[16], _args[17], _args[18], _args[19], _args[20] );
			}
			return;
		}

		public void Insert( Icon new_icon = null, string icon_state = null, double? dir = null, int? frame = null, bool? moving = null, dynamic delay = null ) {
			Icon13.oper_insert( this.icon, new_icon, icon_state, ((int)( dir ??0 )), frame ??0, moving == true, delay );
			return;
		}

		public void DrawBox( string c = null, double? x1 = null, double? y1 = null, double? x2 = null, double? y2 = null ) {
			Icon13.oper_draw_box( this.icon, c, ((int?)( x1 )), ((int?)( y1 )), ((int?)( x2 )), ((int?)( y2 )) );
		}

		public void SwapColor( string o = null, string n = null ) {
			Icon13.oper_swap_color( this.icon, o, n );
		}

		public void Blend( dynamic icon = null, int? f = null, double? x = null, double? y = null ) {
			x = x ?? 1;
			y = y ?? 1;

			Icon13.oper_blend( this.icon, icon, f, ((int?)( x )), ((int?)( y )) );
		}

		public void SetIntensity( int r = 0, int? g = null, int? b = null ) {
			g = g ?? -1;
			b = b ?? -1;

			Icon13.oper_set_intensity( this.icon, r, g ??0, b ??0 );
		}

		public void Shift( double? dir = null, int offset = 0, dynamic wrap = null ) {
			Icon13.oper_shift( this.icon, dir, offset, wrap );
		}

		public void Flip( dynamic dir = null ) {
			Icon13.oper( 6, this.icon, dir );
		}

		public void Turn( dynamic angle = null, dynamic antialias = null ) {
			
			if ( Lang13.Bool( antialias ) ) {
				Icon13.oper( 9, this.icon, angle );
			}
			Icon13.oper( 5, this.icon, angle );
		}

		public ByTable IconStates( int? mode = null ) {
			mode = mode ?? 0;

			return Icon13.States( this.icon, mode ??0 );
		}

		public dynamic RscFile(  ) {
			return File13.Cache( this.icon );
		}

		[VerbInfo( name: "Icon" )]
		public Base_Icon f_Icon(  ) {
			return this.icon;
		}

	}

}