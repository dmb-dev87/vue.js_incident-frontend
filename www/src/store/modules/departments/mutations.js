export default {
    // communicate directly with the state variables
    setSector : (state,sector) => state.SectorCode = sector,
    setOrganization : (state,organization) => state.employees = organization,
    AddOrganizationToSec : (state, organization) => state.Orgs.push(organization),
    removeOrganization : (state,id) => state.employees =  state.employees.filter(org => org.id != id),
    SameSectors: (state,departments) => state.departments = departments,
    saveOrg (state , payload) {
       state.employees.push(payload)
    } 
 }