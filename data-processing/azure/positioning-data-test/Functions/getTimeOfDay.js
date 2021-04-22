// Sample UDF which returns sum of two values.
function getTimeOfDay(dateTime) {

    const timeOfDayConfig = {
        'morning': {
            startTime: '6:00',
            endTime: '10:00'
        },
        'midday': {
            startTime: '10:00',
            endTime: '14:00'
        },
        'afternoon': {
            startTime: '14:00',
            endTime: '18:00'
        },
        'evening':{
            startTime: '18:00',
            endTime: '22:00'
        }
    }
    
    const valueTime = new Date(dateTime).getTime();
    let result = 'night';

    Object.entries(timeOfDayConfig).some(([key, value]) => {
    	const startTime = new Date(`2021-04-12T${value.startTime}`).getTime();
      const endTime = new Date(`2021-04-12T${value.endTime}`).getTime();
      if(valueTime >= startTime && valueTime < endTime ){
      	result = key;
        return true;
      }
    })
    
    return result;
}