                        SELECT   o.Id, o.Name, o.Address, n.Name, d.Name
                        FROM Owner o
                        LEFT JOIN Neighborhood n ON o.NeighborhoodId = n.Id
                        LEFT JOIN Dog d ON d.OwnerId = o.Id
                        --WHERE Id = o.id
                       ORDER BY o.Name ASC
                         --Group BY o.Name, o.Id, o.Address, n.Name, d.Name
                         --ORDER BY o.Name ASC





                        SELECT   o.Id, o.Name, o.Address, n.Name, d.Name
                        FROM Owner o
                        LEFT JOIN Neighborhood n ON o.NeighborhoodId = n.Id
                        LEFT JOIN Dog d ON d.OwnerId = o.Id
                       ORDER BY o.Name ASC
                         