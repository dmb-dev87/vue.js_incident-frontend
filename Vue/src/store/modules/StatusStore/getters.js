export default {

   // getSectors: (state) => state.sectors,
    getOrganizations : (state) => state.status.filter(sec=>sec.sector == state.SectorCode),
    getOrgs : (state) => state.Orgs,
    GetSector : (state) => state.statusType,
    
     
}



