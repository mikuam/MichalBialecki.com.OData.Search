import React, { useState, useEffect } from 'react';
import useConstant from 'use-constant';
import AwesomeDebouncePromise from 'awesome-debounce-promise';

export default () => {

    const [profiles, setProfiles] = useState([]);
    const [firstName, setFirstName] = useState('');
    const [lastName, setLastName] = useState('');
    const [city, setCity] = useState('');

    useEffect(() => {
        populateProfileData();
    }, []);

    const handleFirstNameChange = (event) => {
        setFirstName(event.target.value);
        debouncedPopulateProfileData(event.target.value, lastName, city);
    }

    const handleLastNameChange = (event) => {
        setLastName(event.target.value);
        debouncedPopulateProfileData(firstName, event.target.value, city);
    }

    const handleCityChange = (event) => {
        setCity(event.target.value);
        debouncedPopulateProfileData(firstName, lastName, event.target.value);
    }

    const populateProfileData = async (fn, ln, ci) => {

        var url = 'odata/profiles?$top=25';

        var queries = [];
        if (fn !== undefined && fn !== '') {
            queries.push('contains(FirstName,\'' + fn + '\')');
        }

        if (ln !== undefined && ln !== '') {
            queries.push('contains(LastName,\'' + ln + '\')');
        }

        if (ci !== undefined && ci !== '') {
            queries.push('contains(City,\'' + ci + '\')');
        }

        if (queries.length > 0) {
            url += '&$filter=' + queries.join(' And ');
        }
        console.log('url', url);
        const response = await fetch(url);
        const data = await response.json();
        setProfiles(data.value);
    }

    const debouncedPopulateProfileData = useConstant(() => AwesomeDebouncePromise(populateProfileData, 300));

    return (
        <div>
            <h1 id="tabelLabel">User profiles</h1>
            <p>This component demonstrates fetching data from the server with OData.</p>
            <form>
                <div className="form-row">
                    <div className="form-group col-md-6">
                        <label htmlFor="firstname">Firstname</label>
                        <input type="text" className="form-control" id="firstname" placeholder="John" onChange={handleFirstNameChange} />
                    </div>
                    <div className="form-group col-md-6">
                        <label htmlFor="lastname">Lastname</label>
                        <input type="text" className="form-control" id="lastname" placeholder="Wick" onChange={handleLastNameChange} />
                    </div>
                </div>
                <div className="form-group">
                    <label htmlFor="city">City</label>
                    <input type="text" className="form-control" id="city" placeholder="Los Angeles" onChange={handleCityChange} />
                </div>

                <table className='table table-striped' aria-labelledby="tabelLabel">
                    <thead>
                        <tr>
                            <th>FirstName</th>
                            <th>LastName</th>
                            <th>Email</th>
                            <th>Street</th>
                            <th>City</th>
                            <th>PhoneNumber</th>
                        </tr>
                    </thead>
                    <tbody>
                        {profiles.map(profile =>
                            <tr key={profile.Id}>
                                <td>{profile.FirstName}</td>
                                <td>{profile.LastName}</td>
                                <td>{profile.Email}</td>
                                <td>{profile.Street}</td>
                                <td>{profile.City}</td>
                                <td>{profile.PhoneNumber}</td>
                            </tr>
                        )}
                    </tbody>
                </table>
            </form>
        </div>
    );
}
