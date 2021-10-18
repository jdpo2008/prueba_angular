import { NgModule } from '@angular/core';
import { DomSanitizer } from '@angular/platform-browser';
import { MatIconRegistry } from '@angular/material/icon';

@NgModule()
export class IconsModule {
  /**
   * Constructor
   */
  constructor(
    private _domSanitizer: DomSanitizer,
    private _matIconRegistry: MatIconRegistry
  ) {
    // Register icon sets
    this._matIconRegistry.addSvgIconSet(
      this._domSanitizer.bypassSecurityTrustResourceUrl(
        'assets/icons/material-twotone.svg'
      )
    );
    this._matIconRegistry.addSvgIconSetInNamespace(
      'mat_outline',
      this._domSanitizer.bypassSecurityTrustResourceUrl(
        'assets/icons/material-outline.svg'
      )
    );
    this._matIconRegistry.addSvgIconSetInNamespace(
      'mat_solid',
      this._domSanitizer.bypassSecurityTrustResourceUrl(
        'assets/icons/material-solid.svg'
      )
    );
    this._matIconRegistry.addSvgIconSetInNamespace(
      'iconsmind',
      this._domSanitizer.bypassSecurityTrustResourceUrl(
        'assets/icons/iconsmind.svg'
      )
    );
    this._matIconRegistry.addSvgIconSetInNamespace(
      'feather',
      this._domSanitizer.bypassSecurityTrustResourceUrl(
        'assets/icons/feather.svg'
      )
    );
    this._matIconRegistry.addSvgIconSetInNamespace(
      'heroicons_outline',
      this._domSanitizer.bypassSecurityTrustResourceUrl(
        'assets/icons/heroicons-outline.svg'
      )
    );
    this._matIconRegistry.addSvgIconSetInNamespace(
      'heroicons_solid',
      this._domSanitizer.bypassSecurityTrustResourceUrl(
        'assets/icons/heroicons-solid.svg'
      )
    );
    this._matIconRegistry.addSvgIconSetInNamespace(
      'fontawesome_brands',
      this._domSanitizer.bypassSecurityTrustResourceUrl(
        'assets/icons/fontawesome-brands.svg'
      )
    );
    this._matIconRegistry.addSvgIconSetInNamespace(
      'fontawesome_duotone',
      this._domSanitizer.bypassSecurityTrustResourceUrl(
        'assets/icons/fontawesome-duotone.svg'
      )
    );
    this._matIconRegistry.addSvgIconSetInNamespace(
      'fontawesome_light',
      this._domSanitizer.bypassSecurityTrustResourceUrl(
        'assets/icons/fontawesome-light.svg'
      )
    );
    this._matIconRegistry.addSvgIconSetInNamespace(
      'fontawesome_regular',
      this._domSanitizer.bypassSecurityTrustResourceUrl(
        'assets/icons/fontawesome-regular.svg'
      )
    );
    this._matIconRegistry.addSvgIconSetInNamespace(
      'fontawesome_solid',
      this._domSanitizer.bypassSecurityTrustResourceUrl(
        'assets/icons/fontawesome-solid.svg'
      )
    );
    this._matIconRegistry.addSvgIconSetInNamespace(
      'fontawesome_thin',
      this._domSanitizer.bypassSecurityTrustResourceUrl(
        'assets/icons/fontawesome-thin.svg'
      )
    );
  }
}
