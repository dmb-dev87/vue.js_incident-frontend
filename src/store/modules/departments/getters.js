export default {

   // getSectors: (state) => state.sectors,
    getOrganizations : (state) => state.employees.filter(sec=>sec.sector == state.SectorCode),
    getOrgs : (state) => state.Orgs,
    GetSector : (state) => state.departments,
     
}



