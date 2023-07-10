import moment from 'moment';

export const _utils = {
    reverseDate: (date = '', seperator = '/') => date.split(seperator).reverse().join(seperator),
    reverseDateTime: (date = '', seperator = '/') => {
        console.log(date);
        const [d, time] = date.split(' ');

        return `${_utils.reverseDate(d, seperator)} ${time}`;
    },
    splitTimePart: (date = '') => {
        const newDate = moment(date).format('DD/MM/yyyy');
        const dObj = new Date(date);
        const hour = dObj.getHours();
        const minutes = dObj.getMinutes();

        return {
            hour,
            minutes,
            date: newDate,
        }
    }
}