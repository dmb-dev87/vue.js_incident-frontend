export default {
    // communicate directly with the state variables
    setSector : (state,sector) => state.SectorCode = sector,
    setOrganization : (state,organization) => state.status = organization,
    AddOrganizationToSec : (state, organization) => state.Orgs.push(organization),
    removeOrganization : (state,id) => state.status =  state.status.filter(org => org.id != id),
    SameSectors: (state,statusType) => state.statusType = statusType,
    saveOrg (state , payload) {
       state.status.push(payload)
    } 
 }