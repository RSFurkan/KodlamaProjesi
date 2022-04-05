import { Component, OnInit } from '@angular/core'; 
import PerfectScrollbar from 'perfect-scrollbar';
import { Subscription } from 'rxjs';
import { LookUp } from 'src/app/core/models/lookUp';   

declare const $: any;

export interface RouteInfo {
    path: string
    title: string
    isLink: boolean
    icon: string
    class?: string  
}

export const ROUTES: RouteInfo[] = [
    { path: '/department', title: 'OrnekData', isLink: false, icon: 'dashboard'  },
    { path: '/personel', title: 'personel', isLink: false, icon: 'dashboard'  },
    { path: '/personel-department', title: 'PesonelDepartman', isLink: false, icon: 'dashboard'  },
    { path: '/personel-ornek-data-table', title: 'OrnekData', isLink: false, icon: 'dashboard'  },
    { path: '/personel-unvan', title: 'PersonelUnvan', isLink: false, icon: 'dashboard'  },
    { path: '/unvan', title: 'Unvan', isLink: false, icon: 'dashboard' },  
]