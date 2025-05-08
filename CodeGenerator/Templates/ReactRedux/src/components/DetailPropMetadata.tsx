
export interface DetailPropMetadata {
    Name: string;
    Type?: string;
    Caption: string;
    Visible?: boolean;
    ToString?: (item: any) => string;
    Values?:any[];
}
